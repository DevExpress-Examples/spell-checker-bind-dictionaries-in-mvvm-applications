using DevExpress.Mvvm;
using DevExpress.Xpf.SpellChecker;
using DevExpress.XtraSpellChecker;
using System;
using System.Globalization;

namespace DXSpellCheckerBindingDictionaries.ViewModel
{
    public class MainViewModel
    {
        public virtual DictionarySourceCollection Dictionaries { get; set; }
        public virtual SpellChecker SpellChecker { get; set; }
        protected virtual IMessageBoxService MessageBoxService { get { return null; } }

        public MainViewModel()
        {
            // Create a SpellChecker class instance.
            SpellChecker = new SpellChecker();
            // Specify the SpellChecker's properties.
            SpellChecker.SpellingFormType = SpellingFormType.Word;
            SpellChecker.SpellCheckMode = SpellCheckMode.AsYouType;
            SpellChecker.Culture = new CultureInfo("de-DE");
            // Obtain a dictionary collection.
            Dictionaries = GetDictionaries();

            // Subscribe to events
            SpellChecker.RepeatedWordFound += SpellChecker_RepeatedWordFound;
            SpellChecker.CheckCompleteFormShowing += SpellChecker_CheckCompleteFormShowing;

        }

        private void SpellChecker_CheckCompleteFormShowing(object sender, FormShowingEventArgs e)
        {
            MessageBoxService.Show("That's It!");
            e.Handled = true;
        }

        private void SpellChecker_RepeatedWordFound(object sender, RepeatedWordFoundEventArgs e)
        {
            e.Result = SpellCheckOperation.Cancel;
        }

        public DictionarySourceCollection GetDictionaries()
        {
            // Create a dictionary collection.
            var collection = new DictionarySourceCollection();
            
            // Create a Hunspell spell-checking dictionary.
            var dictionary = new HunspellDictionarySource() { Culture = new CultureInfo("de-DE") };

            // Load the dictionary file.
            dictionary.DictionaryUri = new Uri(@"pack://application:,,,/DXSpellCheckerBindingDictionaries;component/Dictionaries/de_DE.dic");
            // Load the affix file.
            dictionary.GrammarUri = new Uri(@"pack://application:,,,/DXSpellCheckerBindingDictionaries;component/Dictionaries/de_DE.aff");
            // Add the dictionary to the collection.
            collection.Add(dictionary);

            var customDictionary = new SpellCheckerCustomDictionarySource() { Culture = new CultureInfo("EN-us") };
            customDictionary.DictionaryUri = new Uri(@"pack://application:,,,/DXSpellCheckerBindingDictionaries;component/Dictionaries/CustomEnglish.dic");
            customDictionary.AlphabetUri = new Uri(@"pack://application:,,,/DXSpellCheckerBindingDictionaries;component/Dictionaries/Alphabet.txt");
            collection.Add(customDictionary);
            return collection;
        }
    }
}


