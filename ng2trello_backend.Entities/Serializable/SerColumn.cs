﻿using System.Collections.Generic;
using System.Linq;

namespace ng2trello_backend.Entities.Serializable
{
    public class SerColumn : SerializableBase
    {
        public SerColumn()
        {

        }
        public SerColumn(Column column)
        {
            Id = column.Id;
            BoardId = column.BoardId;
            CardIds = string.IsNullOrEmpty(column.CardIds) ? new List<int>():column.CardIds.Split('#').Select(int.Parse).ToList();
            Title = column.Title;
        }

        public int Id { get; set; }
        public int BoardId { get; set; }
        public List<int> CardIds { get; set; }
        public string Title { get; set; }
    }
}
