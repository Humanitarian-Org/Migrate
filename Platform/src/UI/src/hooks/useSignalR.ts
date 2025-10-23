import { HubConnection, HubConnectionBuilder, LogLevel } from '@microsoft/signalr';
import { useEffect, useRef, useState } from 'react';

export interface UploadStartedMessage {
  correlationId: string;
  uploadId: string;
  totalRecordsCount: number;
  startedAt: string;
  userId: string;
  fileName: string;
  docId: string;
}

export interface UploadProgressMessage {
  correlationId: string;
  uploadId: string;
  processedRecords: number;
  totalRecords: number;
  percentageComplete: number;
  currentStatus: string;
}

export interface UploadCompletedMessage {
  correlationId: string;
  uploadId: string;
  totalRecords: number;
  successfulRecords: number;
  failedRecords: number;
  completedAt: string;
  status: string;
  errors: string[];
}

export interface SignalRCallbacks {
  onUploadStarted?: (message: UploadStartedMessage) => void;
  onUploadProgress?: (message: UploadProgressMessage) => void;
  onUploadCompleted?: (message: UploadCompletedMessage) => void;
  onConnectionStateChanged?: (connectionState: 'Connected' | 'Disconnected' | 'Connecting' | 'Reconnecting') => void;
}

export const useSignalR = (callbacks?: SignalRCallbacks) => {
  const [connection, setConnection] = useState<HubConnection | null>(null);
  const [connectionState, setConnectionState] = useState<'Connected' | 'Disconnected' | 'Connecting' | 'Reconnecting'>('Disconnected');
  const callbacksRef = useRef(callbacks);

  // Update callbacks ref when callbacks change
  useEffect(() => {
    callbacksRef.current = callbacks;
  }, [callbacks]);

  useEffect(() => {
    const createConnection = async () => {
      try {
        setConnectionState('Connecting');
        
        // First, get connection info from negotiate endpoint
        const negotiateResponse = await fetch('http://localhost:7071/api/negotiate', {
          method: 'POST',
          headers: {
            'Content-Type': 'application/json',
          },
        });

        if (!negotiateResponse.ok) {
          throw new Error(`Failed to negotiate connection: ${negotiateResponse.status}`);
        }

        const connectionInfo = await negotiateResponse.json();

        // Create SignalR connection
        const newConnection = new HubConnectionBuilder()
          .withUrl(connectionInfo.Url, {
            accessTokenFactory: () => connectionInfo.AccessToken,
          })
          .withAutomaticReconnect()
          .configureLogging(LogLevel.Information)
          .build();

        // Set up event handlers
        newConnection.on('uploadStarted', (message: UploadStartedMessage) => {
          console.log('Upload started:', message);
          callbacksRef.current?.onUploadStarted?.(message);
        });

        newConnection.on('uploadProgress', (message: UploadProgressMessage) => {
          console.log('Upload progress:', message);
          callbacksRef.current?.onUploadProgress?.(message);
        });

        newConnection.on('uploadCompleted', (message: UploadCompletedMessage) => {
          console.log('Upload completed:', message);
          callbacksRef.current?.onUploadCompleted?.(message);
        });

        // Connection state handlers
        newConnection.onclose(() => {
          setConnectionState('Disconnected');
          callbacksRef.current?.onConnectionStateChanged?.('Disconnected');
        });

        newConnection.onreconnecting(() => {
          setConnectionState('Reconnecting');
          callbacksRef.current?.onConnectionStateChanged?.('Reconnecting');
        });

        newConnection.onreconnected(() => {
          setConnectionState('Connected');
          callbacksRef.current?.onConnectionStateChanged?.('Connected');
        });

        // Start the connection
        await newConnection.start();
        setConnection(newConnection);
        setConnectionState('Connected');
        callbacksRef.current?.onConnectionStateChanged?.('Connected');

        console.log('SignalR connection established');
      } catch (error) {
        console.error('Error creating SignalR connection:', error);
        setConnectionState('Disconnected');
        callbacksRef.current?.onConnectionStateChanged?.('Disconnected');
      }
    };

    createConnection();

    // Cleanup function
    return () => {
      if (connection) {
        connection.stop();
      }
    };
  }, []);

  const joinUploadGroup = async (correlationId: string) => {
    if (connection && connectionState === 'Connected') {
      try {
        await fetch('http://localhost:7071/api/JoinGroup', {
          method: 'POST',
          headers: {
            'Content-Type': 'application/json',
          },
          body: JSON.stringify({
            connectionId: connection.connectionId,
            correlationId: correlationId,
          }),
        });
        console.log(`Joined upload group for correlation ID: ${correlationId}`);
      } catch (error) {
        console.error('Error joining upload group:', error);
      }
    }
  };

  return {
    connection,
    connectionState,
    joinUploadGroup,
  };
};