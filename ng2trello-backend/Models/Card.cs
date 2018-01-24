using System.Collections.Generic;
using System.Linq;
using ng2trello_backend.Models.Serializable;

namespace ng2trello_backend.Models
{
  public class Card
  {
    public Card()
    {

    }

    public Card(SerCard card)
    {
      Id = card.Id;
      ParticipantIds = string.Join('#', card.ParticipantIds);
      BoardId = card.BoardId;
      CreationTimestamp = card.CreationTimestamp;
      ExpirationTimestamp = card.ExpirationTimestamp;
      ColumnId = card.ColumnId;
      ActionIds = string.Join('#', card.ActionIds);
      Labels = string.Join('#', card.Labels);
      TodolistId = card.TodolistId;
      CommentIds = string.Join('#', card.CommentIds);
    }

    public int Id { get; set; }
    public string ParticipantIds { get; set; }
    public int BoardId { get; set; }
    public long CreationTimestamp { get; set; }
    public long ExpirationTimestamp { get; set; }
    public int ColumnId { get; set; }
    public string ActionIds { get; set; }
    public string Labels { get; set; }
    public int? TodolistId { get; set; }
    public string CommentIds { get; set; }

    public List<int> GetParticipantIds()
    {
      return string.IsNullOrEmpty(ParticipantIds)
        ? new List<int>()
        : ParticipantIds.Split('#').Select(int.Parse).ToList();
    }

    public void SetParticipantIds(List<int> participantIds)
    {
      ParticipantIds = string.Join('#', participantIds);
    }

    public void AddParticipantId(int id)
    {
      if (GetParticipantIds().Count < 1)
      {
        ParticipantIds = id.ToString();
      }
      else
      {
        ParticipantIds = ParticipantIds + '#' + id;
      }
    }

    public void DeleteParticipantId(int id)
    {
      var currentIds = GetParticipantIds();
      if (currentIds.Contains(id))
      {
        SetParticipantIds(currentIds.Where(x => x != id).ToList());
      }
    }

    public List<int> GetActionIds()
    {
      return string.IsNullOrEmpty(ActionIds)
        ? new List<int>()
        : ActionIds.Split('#').Select(int.Parse).ToList();
    }

    public void SetActionIds(List<int> ids)
    {
      ActionIds = string.Join('#', ids);
    }

    public void AddActionId(int id)
    {
      if (GetActionIds().Count < 1)
      {
        ActionIds = id.ToString();
      }
      else
      {
        ActionIds = ActionIds + '#' + id;
      }
    }

    public void DeleteActionId(int id)
    {
      var currentIds = GetActionIds();
      if (currentIds.Contains(id))
      {
        SetActionIds(currentIds.Where(x => x != id).ToList());
      }
    }

    public List<int> GetCommentIds()
    {
      return string.IsNullOrEmpty(CommentIds)
        ? new List<int>()
        : CommentIds.Split('#').Select(int.Parse).ToList();
    }

    public void SetCommentIds(List<int> ids)
    {
      CommentIds = string.Join('#', ids);
    }

    public void AddCommentId(int id)
    {
      if (GetCommentIds().Count < 1)
      {
        CommentIds = id.ToString();
      }
      else
      {
        CommentIds = CommentIds + '#' + id;
      }
    }

    public void DeleteCommentId(int id)
    {
      var currentIds = GetCommentIds();
      if (currentIds.Contains(id))
      {
        SetCommentIds(currentIds.Where(x => x != id).ToList());
      }
    }

    public List<string> GetLabels()
    {
      return string.IsNullOrEmpty(Labels)
        ? new List<string>()
        : Labels.Split('#').ToList();
    }

    public void SetLabels(List<string> labels)
    {
      Labels = string.Join('#', labels);
    }

    public void AddLabel(string label)
    {
      if (GetCommentIds().Count < 1)
      {
        Labels = label;
      }
      else
      {
        Labels = Labels + '#' + label;
      }
    }

    public void DeleteLabel(string label)
    {
      var currentIds = GetLabels();
      if (currentIds.Contains(label))
      {
        SetLabels(currentIds.Where(x => x != label).ToList());
      }
    }
  }
}
