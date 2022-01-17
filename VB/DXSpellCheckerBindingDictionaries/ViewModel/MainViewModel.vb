Imports System
Imports DevExpress.Xpf.SpellChecker
Imports System.Globalization

Namespace DXSpellCheckerBindingDictionaries.ViewModel

#Region "#ViewModel"
    Public Class MainViewModel

        Public Overridable Property Dictionaries As DictionarySourceCollection

        Public Overridable Property SpellChecker As SpellChecker

        Public Sub New()
            Dictionaries = GetDictionaries()
            SpellChecker = New SpellChecker()
            SpellChecker.SpellingFormType = DevExpress.XtraSpellChecker.SpellingFormType.Word
            SpellChecker.SpellCheckMode = DevExpress.XtraSpellChecker.SpellCheckMode.AsYouType
            SpellChecker.Culture = New CultureInfo("de-DE")
        End Sub

        Public Function GetDictionaries() As DictionarySourceCollection
            Dim collection = New DictionarySourceCollection()
            Dim dictionary = New HunspellDictionarySource()
            dictionary.Culture = New CultureInfo("de-DE")
            dictionary.DictionaryUri = New Uri("pack://application:,,,/DXSpellCheckerBindingDictionaries;component/Dictionaries/de_DE.dic")
            dictionary.GrammarUri = New Uri("pack://application:,,,/DXSpellCheckerBindingDictionaries;component/Dictionaries/de_DE.aff")
            collection.Add(dictionary)
            Return collection
        End Function
    End Class
#End Region  ' #ViewModel
End Namespace
