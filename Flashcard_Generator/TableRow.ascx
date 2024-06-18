<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TableRow.ascx.cs" Inherits="Flashcard_Generator.TableRow" %>


<td class="flashcad-table-row-cell"><%= FlashcardTableRow.WordTarget %> <br /> <%= FlashcardTableRow.WordSource%></td>
<td class="flashcad-table-row-cell"><%= FlashcardTableRow.ExampleSentenceTarget %> <br /> <%= FlashcardTableRow.Pronunciation%> <br /> <%= FlashcardTableRow.ExampleSentenceSource%></td>
<td class="flashcad-table-row-cell"><%= FlashcardTableRow.Tips %></td>
<td class="flashcad-table-row-cell"><%= FlashcardTableRow.Proficiency %></td>


<td class="flashcad-table-row-cell"><button class="td-icon" onclick='deleteFlashcard(<%# FlashcardTableRow.Id %>)'><img src="assets/icons/bin.png" alt="delete"/></button></td>
<td class="flashcad-table-row-cell"><button type="button" class="td-icon" 
onclick='showModal(

<%# FlashcardTableRow.Id %>, 
"<%= FlashcardTableRow.WordTarget %>", 
"<%= FlashcardTableRow.WordSource %>", 
"<%= FlashcardTableRow.ExampleSentenceTarget %>", 
"<%= FlashcardTableRow.Pronunciation %>", 
"<%= FlashcardTableRow.ExampleSentenceSource %>", 
"<%= FlashcardTableRow.Tips %>", 
"<%= FlashcardTableRow.Proficiency %>"       )'><img src="assets/icons/edit.png" alt="edit"/></button></td>


