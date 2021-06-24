using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExThrower = CoreTools.Throws.ExceptionThrower;

namespace CoreTools.Extensions
{
    public static class DictionaryExtensions
    {
        public static Dictionary<TKey, TValue> AddRange<TKey, TValue>(
            this Dictionary<TKey, TValue> @this, 
            Dictionary<TKey, TValue> rangeToAdd, 
            bool overwriteIfKeyExists)
        {
            ExThrower.ST_ThrowIfArgumentIsNull(rangeToAdd, nameof(rangeToAdd));

            if (rangeToAdd.Count == 0)
                return @this;

            rangeToAdd.ForEach(keyValue =>
            {
                if (!@this.ContainsKey(keyValue.Key))
                    @this.Add(keyValue.Key, keyValue.Value);
                else
                if (overwriteIfKeyExists)
                    @this[keyValue.Key] = keyValue.Value;
            });

            return @this;
        }

        public static void JoinMany<TKey, TValue>(
            this Dictionary<TKey, TValue> @this, 
            bool overwriteIfKeyExist, 
            bool allowNullParam, 
            params Dictionary<TKey, TValue>[] dictionaries)
        {
            ExThrower.ST_ThrowIfArgumentIsNull(dictionaries, nameof(dictionaries));

            foreach (var dict in dictionaries)
            {
                if (dict == null)
                {
                    if (!allowNullParam)
                        ExThrower.ST_ThrowArgumentNullException("An element in dictionaries is null");
                }
                else
                    @this.AddRange(dict, overwriteIfKeyExist);
            }
        }

        public static bool TryGetValueIfInputContainKey<TValue>(
            this Dictionary<string, TValue> @this, 
            string input, out TValue value)
        {
            return @this.TryGetValueIfInputContainsKey(input, out value, null);
        }

        public static bool TryGetValueIfInputContainsKey<TValue>(
            this Dictionary<string, TValue> @this, 
            string input, 
            out TValue value, 
            params string[] keysToSkip)
        {
            value = default;
            if (@this.Count == 0)
                return false;
            if (input == null)
                return false;

            foreach (var keyValue in @this)
            {
                if (keysToSkip == null || !keysToSkip.Contains(keyValue.Key))
                    if (input.IgnoreCaseContains(keyValue.Key))
                    {
                        value = keyValue.Value;
                        return true;
                    }
            }

            return false;
        }

        public static bool RenameKeyOrAddNew<TKey, TValue>(
            this Dictionary<TKey, TValue> @this,
            TKey key,
            TKey newKey,
            TValue value)
        {
            ExThrower.ST_ThrowIfArgumentIsNull(key, nameof(key));
            ExThrower.ST_ThrowIfArgumentIsNull(newKey, nameof(newKey));

            if (@this.ContainsKey(newKey))
                return false;
            
            @this.Add(newKey, value);
            @this.Remove(key);

            return true;
        }

        public static void AddOrReplace<TKey, TValue>(
            this Dictionary<TKey, TValue> @this, 
            TKey key, 
            TValue value)
        {
            if (@this.ContainsKey(key))
                @this[key] = value;
            else
                @this.Add(key, value);
        }
    }
}
