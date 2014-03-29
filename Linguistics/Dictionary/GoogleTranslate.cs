﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Linguistics.Utilities;
using Newtonsoft.Json.Linq;
using LemmaSharp;

namespace Linguistics.Dictionary
{
    public class GoogleTranslate: IWebDictionary
    {
        ILemmatizer lmtz = new LemmatizerPrebuiltCompact(LemmaSharp.LanguagePrebuilt.English);

        public async Task<WordTranslation> GetTranslation(string word, Lang inputLang, Lang outputLang)
        {
            string lemma = lmtz.Lemmatize(word.Trim().ToLower());

            string url = String.Format("http://translate.google.com/translate_a/t?client=t&sl={0}&tl={1}&hl={0}&sc=2&ie=UTF-8&oe=UTF-8&ssel=0&tsel=0&q={2}", inputLang, outputLang, lemma);

            string result = "";
            try
            {
                result = HttpQuery.Make(url);
            }
            catch (Exception ex)
            {
                throw new Exception("Http connection problem", ex);
            }

            return getTranslations(lemma, result);
        }

        private WordTranslation getTranslations(string word, string data)
        {
            JArray a = JArray.Parse(data);
            var trans = a[1].Select(x => x[1]); 

            var result = new List<string>();

            foreach (var t in trans)
            {
                result.AddRange(t.Take(2).Select(x => x.ToString()));
            }

            return new WordTranslation() { Translations = result.ToArray(), WordName = word };
        }
    }
}
