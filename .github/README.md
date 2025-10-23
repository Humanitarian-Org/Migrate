# GitHub Repository Configuration for Business-Driven Validation Workflow

This directory contains the GitHub Actions workflows and configuration files needed to enable the business-driven validation rule update system described in `Beneficiary/docs/business-driven-validation-workflow.md`.

## Files Overview

### Workflows
- `validation-rules-sync.yml` - Main workflow that detects changes to validation rules and creates issues for Copilot agent processing

### Configuration
- `.gitignore` - Excludes temporary workflow files from version control

## How It Works

1. **Trigger**: When `Beneficiary/docs/beneficiary-validation-rules.md` is modified
2. **Detection**: Workflow detects changes using git diff
3. **Issue Creation**: Automatically creates GitHub issue with change details
4. **Copilot Integration**: Issue is formatted with instructions for GitHub Copilot agent
5. **Code Generation**: Copilot agent analyzes changes and generates code updates
6. **Review Process**: Pull request created for developer review and approval

## Required GitHub Settings

See the main workflow documentation for complete setup instructions including:
- Actions permissions
- Branch protection rules
- Copilot configuration
- Required status checks

## Manual Testing

To test the workflow manually:

```bash
# Trigger the workflow manually
gh workflow run validation-rules-sync.yml -f force_sync=true
```

Or make a test change to the validation rules file and commit it.

## Monitoring

- Check the **Actions** tab to monitor workflow runs
- Check **Issues** tab for auto-generated validation sync issues  
- Monitor **Pull Requests** for Copilot-generated code changes

## Troubleshooting

Common issues and solutions:

1. **Workflow not triggering**: Check file path in workflow trigger matches exactly
2. **Permission denied**: Verify Actions have write permissions for issues and PRs
3. **Copilot not responding**: Ensure Copilot Business/Enterprise is enabled and agent is configured
4. **Duplicate issues**: Workflow automatically closes existing open issues to prevent duplicates

For more detailed troubleshooting, see the workflow logs in the Actions tab.