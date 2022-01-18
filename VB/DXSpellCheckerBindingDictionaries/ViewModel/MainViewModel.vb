Imports System
Imports System.Globalization
#Region "#usings"
Imports DevExpress.Xpf.SpellChecker
Imports DevExpress.XtraSpellChecker

#End Region  ' #usings
Namespace DXSpellCheckerBindingDictionaries.ViewModel

#Region "#ViewModel"
    Public Class MainViewModel

        Public Overridable Property Dictionaries As DictionarySourceCollection

        Public Overridable Property SpellChecker As SpellChecker

        Public Sub New()
            ' Create a SpellChecker class instance.
            SpellChecker = New SpellChecker()
            ' Specify the SpellChecker's properties.
            SpellChecker.SpellingFormType = SpellingFormType.Word
            SpellChecker.SpellCheckMode = SpellCheckMode.AsYouType
            SpellChecker.Culture = New CultureInfo("de-DE")
            ' Obtain a dictionary collection.
            Dictionaries = GetDictionaries()
        End Sub

        Public Function GetDictionaries() As DictionarySourceCollection
            ' Create a dictionary collection.
            Dim collection = New DictionarySourceCollection()
            ' Create a Hunspell spell-checking dictionary.
            Dim dictionary = New HunspellDictionarySource()
            ' Specify the dictionary culture settings.
            dictionary.Culture = New CultureInfo("de-DE")
            ' Load the dictionary file.
            dictionary.DictionaryUri = New Uri("pack://application:,,,/DXSpellCheckerBindingDictionaries;component/Dictionaries/de_DE.dic")
            ' Load the affix file.
            dictionary.GrammarUri = New Uri("pack://application:,,,/DXSpellCheckerBindingDictionaries;component/Dictionaries/de_DE.aff")
            ' Add the dictionary to the collection.
            collection.Add(dictionary)
            Return collection
        End Function
    End Class
#End Region  ' #ViewModel
End Namespace
