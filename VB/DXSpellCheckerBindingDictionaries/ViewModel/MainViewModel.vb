Imports DevExpress.Mvvm
Imports DevExpress.Xpf.SpellChecker
Imports DevExpress.XtraSpellChecker
Imports System.Globalization

Namespace DXSpellCheckerBindingDictionaries.ViewModel

    Public Class MainViewModel

        Public Overridable Property Dictionaries As DictionarySourceCollection

        Public Overridable Property SpellChecker As SpellChecker

        Protected Overridable ReadOnly Property MessageBoxService As IMessageBoxService
            Get
                Return Nothing
            End Get
        End Property

        Public Sub New()
            ' Create a SpellChecker class instance.
            SpellChecker = New SpellChecker()
            ' Specify the SpellChecker's properties.
            SpellChecker.SpellingFormType = SpellingFormType.Word
            SpellChecker.SpellCheckMode = SpellCheckMode.AsYouType
            SpellChecker.Culture = New CultureInfo("de-DE")
            ' Obtain a dictionary collection.
            Dictionaries = GetDictionaries()
            ' Subscribe to events
            Me.SpellChecker.RepeatedWordFound += AddressOf SpellChecker_RepeatedWordFound
            Me.SpellChecker.CheckCompleteFormShowing += AddressOf SpellChecker_CheckCompleteFormShowing
        End Sub

        Private Sub SpellChecker_CheckCompleteFormShowing(ByVal sender As Object, ByVal e As FormShowingEventArgs)
            MessageBoxService.Show("That's It!")
            e.Handled = True
        End Sub

        Private Sub SpellChecker_RepeatedWordFound(ByVal sender As Object, ByVal e As RepeatedWordFoundEventArgs)
            e.Result = SpellCheckOperation.Cancel
        End Sub

        Public Function GetDictionaries() As DictionarySourceCollection
            ' Create a dictionary collection.
            Dim collection = New DictionarySourceCollection()
            ' Create a Hunspell spell-checking dictionary.
            Dim dictionary = New HunspellDictionarySource() With {.Culture = New CultureInfo("de-DE")}
            ' Load the dictionary file.
            dictionary.DictionaryUri = New Uri("pack://application:,,,/DXSpellCheckerBindingDictionaries;component/Dictionaries/de_DE.dic")
            ' Load the affix file.
            dictionary.GrammarUri = New Uri("pack://application:,,,/DXSpellCheckerBindingDictionaries;component/Dictionaries/de_DE.aff")
            ' Add the dictionary to the collection.
            collection.Add(dictionary)
            Dim customDictionary = New SpellCheckerCustomDictionarySource() With {.Culture = New CultureInfo("EN-us")}
            customDictionary.DictionaryUri = New Uri("pack://application:,,,/DXSpellCheckerBindingDictionaries;component/Dictionaries/CustomEnglish.dic")
            customDictionary.AlphabetUri = New Uri("pack://application:,,,/DXSpellCheckerBindingDictionaries;component/Dictionaries/Alphabet.txt")
            collection.Add(customDictionary)
            Return collection
        End Function
    End Class
End Namespace
