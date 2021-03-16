using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Collections.Generic;

namespace ClassLibrary1
{
    public class _MyClass_
    {

        private Dictionary<string, int> Read(string _String_)
        {
            

                Dictionary<string, int> _Dictionary_ = new Dictionary<string, int>();
                var Words_in_text = _String_.Split(' ', '-', ':', ';', '.', ',', '"', '\'', '!', '?', '\n', ',', '[', ']', '(', ')', '{', '}', '»', '«', '…').Where(string_in_processing => !string.IsNullOrEmpty(string_in_processing));
                var uniqueWords = Words_in_text.Select(string_in_processing => string_in_processing.ToLower().Trim()).Distinct();
                foreach (var m in uniqueWords)
                {
                    _Dictionary_.Add(m, Words_in_text.Count(string_in_processing => string_in_processing.ToLower().Equals(m)));
                }
                _Dictionary_ = _Dictionary_.OrderByDescending(string_in_processing => string_in_processing.Value).ToList().ToDictionary(key => key.Key, value => value.Value);
            return _Dictionary_;
            
            
        }

    }
    public class MyClass
    {

        public Dictionary<string, int> Read(string _String_)
        {
            var Words_in_text = _String_.Split(' ', '-', ':', ';', '.', ',', '"', '\'', '!', '?', '\n', ',', '[', ']', '(', ')', '{', '}', '»', '«', '…').Where(string_in_processing => !string.IsNullOrEmpty(string_in_processing));
            var uniqueWords = Words_in_text.Select(string_in_processing => string_in_processing.ToLower().Trim()).Distinct();
            var __Dictionary__ = new Dictionary<string, int>();
            
            Parallel.ForEach(uniqueWords, word => {
                __Dictionary__.Add(word, Words_in_text.Count(string_in_processing => string_in_processing.ToLower().Equals(word)));
            });

            __Dictionary__ = __Dictionary__.OrderByDescending(string_in_processing => string_in_processing.Value).ToList().ToDictionary(key => key.Key, value => value.Value);

            return (__Dictionary__);
        }
    }
}
