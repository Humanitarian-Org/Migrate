param(
    [Parameter(Mandatory=$true)]
    [string]$Title,
    
    [Parameter(Mandatory=$true)]
    [string]$Body,
    
    [string]$ProjectNumber = "1",
    [string]$Organization = "AIS-Commercial-Business-Unit"
)

# First, let's see which repositories exist
Write-Host "Available repositories in $Organization:"
gh repo list $Organization --limit 20

# Try to create an issue in a suitable repository
# Since the project URL points to project #1, let's use a general repository
$Repositories = @(
    "$Organization/.github",
    "$Organization/github-enablement",
    "$Organization/north-star"
)

foreach ($repo in $Repositories) {
    try {
        Write-Host "Attempting to create issue in $repo..."
        gh issue create --repo $repo --title $Title --body $Body
        
        # If successful, try to add to project
        $IssueUrl = gh issue list --repo $repo --limit 1 --json url --jq '.[0].url'
        if ($IssueUrl) {
            Write-Host "Issue created: $IssueUrl"
            
            # Try to add to project (this might require additional permissions)
            try {
                gh project item-add $ProjectNumber --owner $Organization --url $IssueUrl
                Write-Host "Issue added to project #$ProjectNumber"
            }
            catch {
                Write-Warning "Could not add issue to project: $_"
                Write-Host "You can manually add the issue to the project at: https://github.com/orgs/$Organization/projects/$ProjectNumber"
            }
        }
        return
    }
    catch {
        Write-Warning "Failed to create issue in $repo : $_"
        continue
    }
}

Write-Error "Could not create issue in any repository"
