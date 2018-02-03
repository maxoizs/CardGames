using System.Collections.Generic;

namespace CardGame
{
    /// <summary>
    /// <see cref="CardGame"/> Card
    /// </summary>
    public class Card
    {
        public CardShape Shape { get; set; }
        public CardName Name { get; set; }
        public CardColor Color { get; set; }

        protected bool Equals(Card other)
        {
            return Shape == other.Shape && Name == other.Name && Color == other.Color;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            if (obj.GetType() != this.GetType())
            {
                return false;
            }
            return Equals((Card) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (int) Shape;
                hashCode = (hashCode*397) ^ (int) Name;
                hashCode = (hashCode*397) ^ (int) Color;
                return hashCode;
            }
        }
    }
}
