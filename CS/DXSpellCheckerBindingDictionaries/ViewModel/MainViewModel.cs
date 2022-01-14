using DevExpress.Mvvm.POCO;
using System;
using DevExpress.Xpf.SpellChecker;
using System.Globalization;
using DevExpress.Mvvm.DataAnnotations;

namespace DXSpellCheckerBindingDictionaries.ViewModel
{
    #region #ViewModel
    public class MainViewModel
    {
        public virtual DictionarySourceCollection Dictionaries { get; set; }
        public virtual SpellChecker SpellChecker { get; set; }
        public MainViewModel()
        {
            Dictionaries = GetDictionaries();
            SpellChecker = new SpellChecker();
            SpellChecker.SpellingFormType = DevExpress.XtraSpellChecker.SpellingFormType.Word;
            SpellChecker.SpellCheckMode = DevExpress.XtraSpellChecker.SpellCheckMode.AsYouType;
            SpellChecker.Culture = new CultureInfo("de-DE");

        }

        public DictionarySourceCollection GetDictionaries()
        {
            var collection = new DictionarySourceCollection();

            var dictionary = new HunspellDictionarySource();
            dictionary.Culture = new CultureInfo("de-DE");            
            dictionary.DictionaryUri = new Uri(@"pack://application:,,,/DXSpellCheckerBindingDictionaries;component/Dictionaries/de_DE.dic");
            dictionary.GrammarUri = new Uri(@"pack://application:,,,/DXSpellCheckerBindingDictionaries;component/Dictionaries/de_DE.aff");
            collection.Add(dictionary);
            return collection;
        }
    }
    #endregion #ViewModel
}

