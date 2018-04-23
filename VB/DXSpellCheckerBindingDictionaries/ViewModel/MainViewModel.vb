Imports DevExpress.Mvvm.POCO
Imports System
Imports DevExpress.Xpf.SpellChecker
Imports System.Globalization
Imports DevExpress.Mvvm.DataAnnotations

Namespace DXSpellCheckerBindingDictionaries.ViewModel
    #Region "#ViewModel"
    Public Class MainViewModel
        Public Overridable Property Dictionaries() As DictionarySourceCollection
        Public Sub New()
            Dictionaries = GetDictionaries()
        End Sub

        Public Function GetDictionaries() As DictionarySourceCollection
            Dim collection = New DictionarySourceCollection()

            Dim dictionary = New HunspellDictionarySource()
            dictionary.Culture = New CultureInfo("de-DE")
            dictionary.DictionaryUri = New Uri("pack://application:,,,/Dictionaries/de_DE.dic")
            dictionary.GrammarUri = New Uri("pack://application:,,,/Dictionaries/de_DE.aff")
            collection.Add(dictionary)
            Return collection
        End Function
    End Class
    #End Region ' #ViewModel
End Namespace

