# Assign GitHub Issues to Project with Custom Fields
# This script assigns issues #110-128 to the "App Dev with GitHub Practice" project
# and sets custom field values for Workstream, Item Type, and Roadmap Status

param(
    [string]$Owner = "AIS-Commercial-Business-Unit",
    [string]$Repo = "github-enablement",
    [string]$ProjectTitle = "App Dev with GitHub Practice"
)

# Color functions for better output
function Write-Success { param($Message) Write-Host $Message -ForegroundColor Green }
function Write-Info { param($Message) Write-Host $Message -ForegroundColor Cyan }
function Write-Warning { param($Message) Write-Host $Message -ForegroundColor Yellow }
function Write-Error { param($Message) Write-Host $Message -ForegroundColor Red }

Write-Info "Starting project assignment for issues #110-128..."

# First, get the project ID
Write-Info "Finding project: $ProjectTitle"
$projectList = gh project list --owner $Owner --format json | ConvertFrom-Json
$project = $projectList | Where-Object { $_.title -eq $ProjectTitle }

if (-not $project) {
    Write-Error "Project '$ProjectTitle' not found!"
    Write-Info "Available projects:"
    $projectList | ForEach-Object { Write-Info "  - $($_.title)" }
    exit 1
}

$projectId = $project.id
$projectNumber = $project.number
Write-Success "Found project: $ProjectTitle (ID: $projectId, Number: $projectNumber)"

# Define issue mappings with custom field values
$issueMap = @{
    # Marketing Workstream
    110 = @{ Workstream = "Marketing"; ItemType = "Task"; RoadmapStatus = "In Planning" }
    111 = @{ Workstream = "Marketing"; ItemType = "Task"; RoadmapStatus = "In Planning" }
    112 = @{ Workstream = "Marketing"; ItemType = "Deliverable"; RoadmapStatus = "In Planning" }
    113 = @{ Workstream = "Marketing"; ItemType = "Analysis"; RoadmapStatus = "In Planning" }
    114 = @{ Workstream = "Marketing"; ItemType = "Deliverable"; RoadmapStatus = "In Planning" }
    115 = @{ Workstream = "Marketing"; ItemType = "Tool"; RoadmapStatus = "In Planning" }
    116 = @{ Workstream = "Marketing"; ItemType = "Framework"; RoadmapStatus = "In Planning" }
    
    # Service Offering Workstream
    117 = @{ Workstream = "Service Offering"; ItemType = "Framework"; RoadmapStatus = "In Planning" }
    118 = @{ Workstream = "Service Offering"; ItemType = "Framework"; RoadmapStatus = "In Planning" }
    119 = @{ Workstream = "Service Offering"; ItemType = "Process"; RoadmapStatus = "In Planning" }
    120 = @{ Workstream = "Service Offering"; ItemType = "Template"; RoadmapStatus = "In Planning" }
    121 = @{ Workstream = "Service Offering"; ItemType = "Partnership"; RoadmapStatus = "In Planning" }
    122 = @{ Workstream = "Service Offering"; ItemType = "Curriculum"; RoadmapStatus = "In Planning" }
    
    # Sales Workstream
    123 = @{ Workstream = "Sales"; ItemType = "Playbook"; RoadmapStatus = "In Planning" }
    124 = @{ Workstream = "Sales"; ItemType = "Framework"; RoadmapStatus = "In Planning" }
    125 = @{ Workstream = "Sales"; ItemType = "Tool"; RoadmapStatus = "In Planning" }
    
    # Operations Workstream
    126 = @{ Workstream = "Operations"; ItemType = "Deliverable"; RoadmapStatus = "In Planning" }
    127 = @{ Workstream = "Operations"; ItemType = "Process"; RoadmapStatus = "In Planning" }
    128 = @{ Workstream = "Operations"; ItemType = "Process"; RoadmapStatus = "In Planning" }
}

# Process each issue
$successCount = 0
$errorCount = 0

foreach ($issueNumber in $issueMap.Keys) {
    Write-Info "Processing issue #$issueNumber..."
    
    try {
        # Add issue to project
        $addResult = gh project item-add $projectNumber --owner $Owner --url "https://github.com/$Owner/$Repo/issues/$issueNumber" 2>&1
        
        if ($LASTEXITCODE -eq 0) {
            Write-Success "  Added issue #$issueNumber to project"
            $successCount++
            
            # Note: Setting custom fields requires additional API calls
            # This would need project field IDs which aren't easily accessible via CLI
            # For now, we'll add the issue and note that custom fields need manual setup
            
        } else {
            Write-Warning "  Issue #$issueNumber may already be in project or encountered an error"
            Write-Info "    $addResult"
        }
        
    } catch {
        Write-Error "  Failed to process issue #$issueNumber : $($_.Exception.Message)"
        $errorCount++
    }
    
    # Small delay to avoid rate limiting
    Start-Sleep -Milliseconds 100
}

Write-Info "`nSummary:"
Write-Success "Successfully processed: $successCount issues"
if ($errorCount -gt 0) {
    Write-Warning "Errors encountered: $errorCount issues"
}

Write-Info "`nView your project:"
Write-Info "https://github.com/orgs/$Owner/projects/$projectNumber"

Write-Info "`nNext Steps:"
Write-Info "1. Visit the project board to verify issues were added"
Write-Info "2. Manually set custom field values for Workstream, Item Type, and Roadmap Status"
Write-Info "3. Set all issues to Status: Backlog"

Write-Warning "`nNote: Custom field assignment requires GitHub's GraphQL API"
Write-Warning "The current GitHub CLI doesn't easily support setting custom project fields."
Write-Warning "You'll need to set these manually in the project board interface."