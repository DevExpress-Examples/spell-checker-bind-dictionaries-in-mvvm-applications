using DevExpress.Mvvm.POCO;
using System;
using System.Globalization;
using DevExpress.Mvvm.DataAnnotations;
#region #usings
using DevExpress.Xpf.SpellChecker;
using DevExpress.XtraSpellChecker;
#endregion #usings

namespace DXSpellCheckerBindingDictionaries.ViewModel
{
    #region #ViewModel
    public class MainViewModel
    {
        public virtual DictionarySourceCollection Dictionaries { get; set; }
        public virtual SpellChecker SpellChecker { get; set; }

        public MainViewModel()
        {
            // Create a SpellChecker instance.
            SpellChecker = new SpellChecker();
            // Specify the SpellChecker's proterties.
            SpellChecker.SpellingFormType = SpellingFormType.Word;
            SpellChecker.SpellCheckMode = SpellCheckMode.AsYouType;
            SpellChecker.Culture = new CultureInfo("de-DE");
            // Obtain a dictionary collection.
            Dictionaries = GetDictionaries();
        }

        public DictionarySourceCollection GetDictionaries()
        {
            // Create a dictionary collection.
            var collection = new DictionarySourceCollection();
            // Create a Hunspell spell-checking dictionary.
            var dictionary = new HunspellDictionarySource();
            // Specify the dictionary culture settings.
            dictionary.Culture = new CultureInfo("de-DE");
            // Load the dictionary file.
            dictionary.DictionaryUri = new Uri(@"pack://application:,,,/DXSpellCheckerBindingDictionaries;component/Dictionaries/de_DE.dic");
            // Load the affix file.
            dictionary.GrammarUri = new Uri(@"pack://application:,,,/DXSpellCheckerBindingDictionaries;component/Dictionaries/de_DE.aff");
            // Add the dictionary to the collection.
            collection.Add(dictionary);
            return collection;
        }
    }
    #endregion #ViewModel
}

