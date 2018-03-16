using System.Collections.Generic;
using System.Linq;
using ng2trello_backend.Entities.Serializable;

namespace ng2trello_backend.Entities
{
    public class Column
    {
        public Column()
        {

        }

        public Column(SerColumn column)
        {
            Id = column.Id;
            BoardId = column.BoardId;
            CardIds = string.Join('#', column.CardIds);
            Title = column.Title;
        }

        public int Id { get; set; }
        public int BoardId { get; set; }
        public string CardIds { get; set; }
        public string Title { get; set; }

        public List<int> GetCardIds()
        {
            return string.IsNullOrEmpty(CardIds)
              ? new List<int>()
              : CardIds.Split('#').Select(int.Parse).ToList();
        }

        public void AddCardId(int id)
        {
            if (GetCardIds().Count < 1)
            {
                CardIds = id.ToString();
            }
            else
            {
                CardIds = CardIds + '#' + id;
            }
        }

        public void DeleteCardId(int id)
        {
            var cardIds = GetCardIds();
            if (cardIds.Contains(id))
            {
                CardIds = string.Join('#', cardIds.Where(x => x != id));
            }
        }
    }
}
