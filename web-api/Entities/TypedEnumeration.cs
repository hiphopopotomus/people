using System;

namespace webapi.Entities
{
    public abstract class TypedEnumeration<T> : ITypedEnumeration where T : IComparable
    {
        public T Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        protected TypedEnumeration(T id, string name, string description = null)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public override string ToString() => Id.ToString();

        public override bool Equals(object other)
        {
            if (!(other is TypedEnumeration<T> otherValue))
            {
                return false;
            }

            var typeMatches = GetType().Equals(other?.GetType());
            var valueMatches = Id.Equals(otherValue.Id);

            return typeMatches && valueMatches;
        }

        public override int GetHashCode()
        {
            return GetType().GetHashCode() * Id.GetHashCode();
        }

        public int CompareTo(object other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            return Id.CompareTo(((TypedEnumeration<T>)other).Id);
        }

        public static bool operator ==(TypedEnumeration<T> left, TypedEnumeration<T> right)
        {
            if (ReferenceEquals(left, null))
            {
                return ReferenceEquals(right, null);
            }

            return left.Equals(right);
        }

        public static bool operator !=(TypedEnumeration<T> left, TypedEnumeration<T> right)
        {
            return !(left == right);
        }

        public static bool operator <(TypedEnumeration<T> left, TypedEnumeration<T> right)
        {
            return ReferenceEquals(left, null) ? !ReferenceEquals(right, null) : left.CompareTo(right) < 0;
        }

        public static bool operator <=(TypedEnumeration<T> left, TypedEnumeration<T> right)
        {
            return ReferenceEquals(left, null) || left.CompareTo(right) <= 0;
        }

        public static bool operator >(TypedEnumeration<T> left, TypedEnumeration<T> right)
        {
            return !ReferenceEquals(left, null) && left.CompareTo(right) > 0;
        }

        public static bool operator >=(TypedEnumeration<T> left, TypedEnumeration<T> right)
        {
            return ReferenceEquals(left, null) ? ReferenceEquals(right, null) : left.CompareTo(right) >= 0;
        }
    }
}
