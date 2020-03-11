using System.Collections.Generic;

namespace JobBoard.Models
{
  public class Jobs
  {
    private static int _jobCount = 0;
    public static List<Jobs> Board { get; set; } = new List<Jobs>();

    public string Title { get; set; }

    public string Description { get; set; }

    public string Contact { get; set; }

    public int Index { get; set; }
    public int Id { get; set; }

    public Jobs(string title, string description, string contact)
    {
      Title = title;
      Description = description;
      Contact = contact;
      Index = Board.Count;
      Id = ++_jobCount;
      Board.Add(this);
    }
    public static void ClearAll()
    {
      Board.Clear();
    }

    public static Jobs Find(int id)
    {
      int index = 0;
      foreach (var item in Board)
      {
        if (item.Id == id)
        {
          item.Index = index;
          return item;
        }
        index++;
      }
      return Jobs.Board[0];
    }

    public static void DeletePlace(int id)
    {
      Jobs job = Find(id);
      Board.RemoveAt(job.Index);
    }

    public static void UpdatePlace(int id, string title, string description, string contact)
    {
      Jobs job = Find(id);
      job.Title = title;
      job.Description = description;
      job.Contact = contact;

    }


  }
}