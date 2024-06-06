<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TableRow.ascx.cs" Inherits="Flashcard_Generator.TableRow" %>


<td><%= FlashcardTableRow.User.Username %></td>
<td><%= FlashcardTableRow.SourceLanguage%> - <%= FlashcardTableRow.TargetLanguage%></td>
<td><%= FlashcardTableRow.Category %></td>
<td><%= FlashcardTableRow.WordTarget %> <br /> <%= FlashcardTableRow.WordSource%></td>
<td><%= FlashcardTableRow.ExampleSentenceTarget %> <br /> <%= FlashcardTableRow.Pronunciation%> <br /> <%= FlashcardTableRow.ExampleSentenceSource%></td>
<td><%= FlashcardTableRow.Tips %></td>
<td><%= FlashcardTableRow.Proficiency %></td>
       

