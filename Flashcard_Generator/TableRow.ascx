<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TableRow.ascx.cs" Inherits="Flashcard_Generator.TableRow" %>


<td class="flashcad-table-row-cell"><%= FlashcardTableRow.WordTarget %> <br /> <%= FlashcardTableRow.WordSource%></td>
<td class="flashcad-table-row-cell"><%= FlashcardTableRow.ExampleSentenceTarget %> <br /> <%= FlashcardTableRow.Pronunciation%> <br /> <%= FlashcardTableRow.ExampleSentenceSource%></td>
<td class="flashcad-table-row-cell"><%= FlashcardTableRow.Tips %></td>
<td class="flashcad-table-row-cell"><%= FlashcardTableRow.Proficiency %></td>
<td class="flashcad-table-row-cell"><%= FlashcardTableRow.IsPublic %></td>

<td class="flashcad-table-row-cell"><button class="td-icon" type="button" onclick='deleteFlashcard(<%# FlashcardTableRow.Id %>)'><img src="assets/icons/bin.png" alt="delete"/></button></td>
<td class="flashcad-table-row-cell"><button type="button" class="td-icon" 
onclick='showModal(

    <%# FlashcardTableRow.Id %>, 
"<%= HttpUtility.JavaScriptStringEncode(FlashcardTableRow.WordTarget) %>", 
"<%= HttpUtility.JavaScriptStringEncode(FlashcardTableRow.WordSource) %>", 
"<%= HttpUtility.JavaScriptStringEncode(FlashcardTableRow.ExampleSentenceTarget) %>", 
"<%= HttpUtility.JavaScriptStringEncode(FlashcardTableRow.Pronunciation) %>", 
"<%= HttpUtility.JavaScriptStringEncode(FlashcardTableRow.ExampleSentenceSource) %>", 
"<%= HttpUtility.JavaScriptStringEncode(FlashcardTableRow.Tips)  %>", 
"<%= FlashcardTableRow.Proficiency %>" , 
"<%= FlashcardTableRow.IsPublic %>"   )'><img src="assets/icons/edit.png" alt="edit"/></button></td>


