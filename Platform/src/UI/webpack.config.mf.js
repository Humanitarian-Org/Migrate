const ModuleFederationPlugin = require('@module-federation/webpack');
const HtmlWebpackPlugin = require('html-webpack-plugin');
const path = require('path');

module.exports = (env, argv) => {
  const isProduction = argv.mode === 'production';
  
  return {
    mode: argv.mode || 'development',
    entry: './src/index.tsx',
    target: 'web',
    
    devServer: {
      port: 3000,
      historyApiFallback: true,
      hot: true,
      headers: {
        'Access-Control-Allow-Origin': '*',
        'Access-Control-Allow-Methods': 'GET, POST, PUT, DELETE, PATCH, OPTIONS',
        'Access-Control-Allow-Headers': 'X-Requested-With, content-type, Authorization',
      },
      proxy: {
        '/api': {
          target: 'http://localhost:7071',
          changeOrigin: true,
          logLevel: 'debug',
        },
      },
    },
    
    resolve: {
      extensions: ['.tsx', '.ts', '.js', '.jsx'],
    },
    
    module: {
      rules: [
        {
          test: /\.tsx?$/,
          use: [
            {
              loader: 'ts-loader',
              options: {
                transpileOnly: true,
              },
            },
          ],
          exclude: /node_modules/,
        },
        {
          test: /\.css$/,
          use: ['style-loader', 'css-loader'],
        },
      ],
    },
    
    plugins: [
      // Module Federation Plugin - HOST
      new ModuleFederationPlugin({
        name: 'platformHost',
        remotes: {
          // Reference to Beneficiary UI remote
          beneficiaryUI: isProduction 
            ? 'beneficiaryUI@https://beneficiary-ui.acmecorp.org/remoteEntry.js'
            : 'beneficiaryUI@http://localhost:3001/remoteEntry.js',
          // Could add more remotes for other domains
          // medicalUI: 'medicalUI@http://localhost:3002/remoteEntry.js',
        },
        shared: {
          react: { 
            singleton: true, 
            requiredVersion: '^18.2.0',
            eager: true 
          },
          'react-dom': { 
            singleton: true, 
            requiredVersion: '^18.2.0',
            eager: true 
          },
          'react-router-dom': { 
            singleton: true, 
            requiredVersion: '^6.8.0' 
          },
          '@mui/material': { 
            singleton: true, 
            requiredVersion: '^5.11.0' 
          },
          '@mui/icons-material': { 
            singleton: true, 
            requiredVersion: '^5.11.0' 
          },
          '@emotion/react': { 
            singleton: true, 
            requiredVersion: '^11.10.5' 
          },
          '@emotion/styled': { 
            singleton: true, 
            requiredVersion: '^11.10.5' 
          },
        },
      }),
      
      new HtmlWebpackPlugin({
        template: './public/index.html',
        title: 'AcmeCorp Platform',
        inject: true,
      }),
    ],
    
    optimization: {
      splitChunks: false,
    },
  };
};