## Steps to reproduce issue

1. Configure DB ElsaDemo on local SQL server or update appsettings.json in Blazor and DB migrator app to your own DB.
2. Build and run DBmigrator project to create initial seed.
3. Run Blazor app and browse /elsa/dashboard to view the Elsa Dashboard.
4. Create a new workflow and import JSON below.
5. Publish Workflow and exit designer.
6. Open Workflow created in step 4 and launch dev tools.
7. Delete second last activity, designer will auto save. Observe content posted to API, no duplicate IDs will be present in body.
8. Check workflow data in DB, duplicate id will exist.

Attemping any further action should result in server error. Dashboard will be unusable until workflow is deleted from DB or duplicate IDs is corrected
