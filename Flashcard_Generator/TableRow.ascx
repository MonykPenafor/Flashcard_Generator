<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TableRow.ascx.cs" Inherits="Flashcard_Generator.TableRow" %>

<td class="flashcad-table-row-cell"><%= FlashcardTableRow.WordTarget %> <br /> <%= FlashcardTableRow.WordSource%></td>
<td class="flashcad-table-row-cell"><%= FlashcardTableRow.ExampleSentenceTarget %> <br /> <%= FlashcardTableRow.Pronunciation%> <br /> <%= FlashcardTableRow.ExampleSentenceSource%></td>
<td class="flashcad-table-row-cell"><%= FlashcardTableRow.Tips %></td>
<td class="flashcad-table-row-cell"><%= FlashcardTableRow.Proficiency %></td>
<td class="flashcad-table-row-cell"><%= FlashcardTableRow.User.Username %></td>
       
