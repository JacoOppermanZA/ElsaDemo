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

```
{
  "$id": "1",
  "definitionId": "96a4c4547f8b4a92b276f7a28fffae7c",
  "versionId": "cdcda964de884bef8a8fad3d98dd5571",
  "name": "Demo Send Signal",
  "displayName": "Demo Send Signal",
  "version": 1,
  "variables": {
    "$id": "2",
    "data": {}
  },
  "customAttributes": {
    "$id": "3",
    "data": {}
  },
  "isSingleton": false,
  "persistenceBehavior": "WorkflowBurst",
  "deleteCompletedInstances": false,
  "isPublished": true,
  "isLatest": true,
  "activities": [
    {
      "$id": "4",
      "activityId": "739834ea-d45d-4cca-8c41-89d91cd1411e",
      "type": "HttpEndpoint",
      "displayName": "HTTP Endpoint",
      "persistWorkflow": false,
      "loadWorkflowContext": false,
      "saveWorkflowContext": false,
      "properties": [
        {
          "$id": "5",
          "name": "Path",
          "expressions": {
            "$id": "6",
            "Literal": "/signal-demo"
          }
        },
        {
          "$id": "7",
          "name": "Methods",
          "expressions": {
            "$id": "8",
            "Json": "[\"GET\"]"
          }
        },
        {
          "$id": "9",
          "name": "ReadContent",
          "expressions": {
            "$id": "10"
          }
        },
        {
          "$id": "11",
          "name": "TargetType",
          "expressions": {
            "$id": "12"
          }
        },
        {
          "$id": "13",
          "name": "Authorize",
          "expressions": {
            "$id": "14"
          }
        },
        {
          "$id": "15",
          "name": "Policy",
          "expressions": {
            "$id": "16"
          }
        }
      ],
      "propertyStorageProviders": {}
    },
    {
      "$id": "17",
      "activityId": "2183c0ee-feae-4d7f-b137-c1688dd31727",
      "type": "SendSignal",
      "displayName": "Send Signal",
      "persistWorkflow": false,
      "loadWorkflowContext": false,
      "saveWorkflowContext": false,
      "properties": [
        {
          "$id": "18",
          "name": "Signal",
          "expressions": {
            "$id": "19",
            "Literal": "signal-demo"
          }
        },
        {
          "$id": "20",
          "name": "CorrelationId",
          "expressions": {
            "$id": "21"
          }
        },
        {
          "$id": "22",
          "name": "Input",
          "expressions": {
            "$id": "23"
          }
        }
      ],
      "propertyStorageProviders": {}
    },
    {
      "$id": "24",
      "activityId": "12ad5620-bd31-4b67-a67f-af3d259edbc4",
      "type": "WriteHttpResponse",
      "displayName": "HTTP Response",
      "persistWorkflow": false,
      "loadWorkflowContext": false,
      "saveWorkflowContext": false,
      "properties": [
        {
          "$id": "25",
          "name": "Content",
          "expressions": {
            "$id": "26",
            "Literal": "<h2>Signal Sent!</h2>"
          }
        },
        {
          "$id": "27",
          "name": "ContentType",
          "expressions": {
            "$id": "28",
            "Literal": "text/html"
          }
        },
        {
          "$id": "29",
          "name": "StatusCode",
          "expressions": {
            "$id": "30"
          }
        },
        {
          "$id": "31",
          "name": "CharSet",
          "expressions": {
            "$id": "32"
          }
        },
        {
          "$id": "33",
          "name": "ResponseHeaders",
          "expressions": {
            "$id": "34"
          }
        }
      ],
      "propertyStorageProviders": {}
    },
    {
      "$id": "35",
      "activityId": "5fbfa50d-95c1-4f5c-8965-ca25b70392f2",
      "type": "Timer",
      "displayName": "Timer",
      "persistWorkflow": false,
      "loadWorkflowContext": false,
      "saveWorkflowContext": false,
      "properties": [
        {
          "$id": "36",
          "name": "Timeout",
          "expressions": {
            "$id": "37",
            "Literal": "5"
          }
        }
      ],
      "propertyStorageProviders": {}
    },
    {
      "$id": "38",
      "activityId": "646d0121-e74a-4b69-8da1-e0cd09402097",
      "type": "Redirect",
      "displayName": "Redirect",
      "persistWorkflow": false,
      "loadWorkflowContext": false,
      "saveWorkflowContext": false,
      "properties": [
        {
          "$id": "39",
          "name": "Location",
          "expressions": {
            "$id": "40",
            "Literal": "https://localhost:44313/elsa/dashboard"
          }
        },
        {
          "$id": "41",
          "name": "Permanent",
          "expressions": {
            "$id": "42"
          }
        }
      ],
      "propertyStorageProviders": {}
    }
  ],
  "connections": [
    {
      "$id": "43",
      "sourceActivityId": "739834ea-d45d-4cca-8c41-89d91cd1411e",
      "targetActivityId": "2183c0ee-feae-4d7f-b137-c1688dd31727",
      "outcome": "Done"
    },
    {
      "$id": "44",
      "sourceActivityId": "2183c0ee-feae-4d7f-b137-c1688dd31727",
      "targetActivityId": "12ad5620-bd31-4b67-a67f-af3d259edbc4",
      "outcome": "Done"
    },
    {
      "$id": "45",
      "sourceActivityId": "12ad5620-bd31-4b67-a67f-af3d259edbc4",
      "targetActivityId": "5fbfa50d-95c1-4f5c-8965-ca25b70392f2",
      "outcome": "Done"
    },
    {
      "$id": "46",
      "sourceActivityId": "5fbfa50d-95c1-4f5c-8965-ca25b70392f2",
      "targetActivityId": "646d0121-e74a-4b69-8da1-e0cd09402097",
      "outcome": "Done"
    }
  ],
  "id": "cdcda964de884bef8a8fad3d98dd5571"
}
```
