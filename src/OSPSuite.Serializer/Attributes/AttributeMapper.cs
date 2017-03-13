using System;
using OSPSuite.Utility.Extensions;

namespace OSPSuite.Serializer.Attributes
{
   public abstract class AttributeMapper<TAttribute, TContext> : IAttributeMapper<TAttribute, TContext>
   {
      public virtual string Convert(object valueToConvert, object context)
      {
         return Convert(valueToConvert.ConvertedTo<TAttribute>(), context.DowncastTo<TContext>());
      }

      public virtual object ConvertFrom(string attributeValue, object context)
      {
         return ConvertFrom(attributeValue, context.DowncastTo<TContext>());
      }

      public abstract object ConvertFrom(string attributeValue, TContext context);

      public virtual bool IsMatch(Type attributeType)
      {
         return attributeType == typeof (TAttribute);
      }

      public Type ObjectType
      {
         get { return typeof (TAttribute); }
      }

      public abstract string Convert(TAttribute valueToConvert, TContext context);
   }
}