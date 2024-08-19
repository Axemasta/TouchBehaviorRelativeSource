using System.Text.Json;
using TouchBehaviorRelativeBinding.Models;

namespace TouchBehaviorRelativeBinding.Helpers;

public static class DisplayItemHelper
{
    public static IEnumerable<DisplayItem> GetDisplayItems()
    {
        return JsonSerializer.Deserialize<IEnumerable<DisplayItem>>(SampleJson) ?? throw new InvalidOperationException("Unable to deserialize SampleJson"); 
    }
    
    private const string SampleJson = 
        """
        [
          {
              "Id": 1,
              "ParentId": null,
              "Type": 1,
              "Title": "Documents",
              "Created": "2023-01-15T10:30:00Z",
              "LastModified": "2023-10-20T14:45:00Z",
              "FileKilobytes": null,
              "FileExtension": null
          },
          {
              "Id": 2,
              "ParentId": 1,
              "Type": 0,
              "Title": "Report.docx",
              "Created": "2023-02-03T09:15:00Z",
              "LastModified": "2023-09-18T11:20:00Z",
              "FileKilobytes": 256,
              "FileExtension": "docx"
          },
          {
              "Id": 3,
              "ParentId": 1,
              "Type": 0,
              "Title": "Presentation.pptx",
              "Created": "2023-03-10T14:20:00Z",
              "LastModified": "2023-08-25T16:05:00Z",
              "FileKilobytes": 180,
              "FileExtension": "pptx"
          },
          {
              "Id": 4,
              "ParentId": null,
              "Type": 1,
              "Title": "Pictures",
              "Created": "2023-04-22T11:40:00Z",
              "LastModified": "2023-10-12T09:55:00Z",
              "FileKilobytes": null,
              "FileExtension": null
          },
          {
              "Id": 5,
              "ParentId": 4,
              "Type": 0,
              "Title": "Vacation.jpg",
              "Created": "2023-05-05T16:55:00Z",
              "LastModified": "2023-09-08T13:10:00Z",
              "FileKilobytes": 120,
              "FileExtension": "jpg"
          },
          {
            "Id": 6,
            "ParentId": null,
            "Type": 0,
            "Title": "Notes.txt",
            "Created": "2023-04-05T16:55:00Z",
            "LastModified": "2023-09-08T13:10:00Z",
            "FileKilobytes": 120,
            "FileExtension": "txt"
        }
        ]
        """;
}