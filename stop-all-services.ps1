# Humanitarian.org Migration Platform - Stop All Services Script
# This script stops all running development servers

Write-Host "🛑 Stopping Humanitarian.org Migration Platform Services..." -ForegroundColor Red
Write-Host ""

# Ports used by our services (including Azurite)
$ports = @(3000, 7071, 7072, 7074, 7075, 10000, 10001, 10002)

# Function to kill processes on a specific port
function Stop-ProcessOnPort($port) {
    try {
        $processes = Get-NetTCPConnection -LocalPort $port -ErrorAction SilentlyContinue | 
                    Select-Object -ExpandProperty OwningProcess | 
                    Get-Process -Id { $_ } -ErrorAction SilentlyContinue
        
        if ($processes) {
            foreach ($process in $processes) {
                Write-Host "Stopping process '$($process.Name)' (PID: $($process.Id)) on port $port" -ForegroundColor Yellow
                Stop-Process -Id $process.Id -Force -ErrorAction SilentlyContinue
            }
            Write-Host "✅ Port $port cleared" -ForegroundColor Green
        } else {
            Write-Host "ℹ️  No processes found on port $port" -ForegroundColor Gray
        }
    }
    catch {
        Write-Host "⚠️  Could not check/stop processes on port $port" -ForegroundColor Yellow
    }
}

# Function to kill processes by name
function Stop-ProcessByName($processName) {
    try {
        $processes = Get-Process -Name $processName -ErrorAction SilentlyContinue
        if ($processes) {
            foreach ($process in $processes) {
                Write-Host "Stopping $processName process (PID: $($process.Id))" -ForegroundColor Yellow
                Stop-Process -Id $process.Id -Force -ErrorAction SilentlyContinue
            }
            Write-Host "✅ All $processName processes stopped" -ForegroundColor Green
        }
    }
    catch {
        # Silently continue if process not found
    }
}

Write-Host "Checking and stopping processes on development ports..." -ForegroundColor Cyan

# Stop processes on each port
foreach ($port in $ports) {
    Stop-ProcessOnPort $port
}

Write-Host ""
Write-Host "Stopping common development processes..." -ForegroundColor Cyan

# Stop common development processes
$processNames = @("node", "func", "dotnet", "azurite")
foreach ($processName in $processNames) {
    Stop-ProcessByName $processName
}

# Special handling for npm/webpack dev servers
try {
    $nodeProcesses = Get-Process -Name "node" -ErrorAction SilentlyContinue | 
                    Where-Object { $_.ProcessName -like "*webpack*" -or $_.CommandLine -like "*react-scripts*" }
    
    if ($nodeProcesses) {
        foreach ($process in $nodeProcesses) {
            Write-Host "Stopping webpack/react dev server (PID: $($process.Id))" -ForegroundColor Yellow
            Stop-Process -Id $process.Id -Force -ErrorAction SilentlyContinue
        }
    }
} catch {
    # Continue silently
}

Write-Host ""
Write-Host "🎉 All development services have been stopped!" -ForegroundColor Green
Write-Host ""
Write-Host "💡 Tip: Run 'start-all-services.ps1' to restart all services" -ForegroundColor Cyan
Write-Host "Press any key to exit..." -ForegroundColor Gray
$null = $Host.UI.RawUI.ReadKey("NoEcho,IncludeKeyDown")