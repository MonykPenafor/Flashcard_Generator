<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TableRow.ascx.cs" Inherits="Flashcard_Generator.TableRow" %>


<td class="flashcad-table-row-cell"><%= FlashcardTableRow.WordTarget %> <br /> <%= FlashcardTableRow.WordSource%></td>
<td class="flashcad-table-row-cell"><%= FlashcardTableRow.ExampleSentenceTarget %> <br /> <%= FlashcardTableRow.Pronunciation%> <br /> <%= FlashcardTableRow.ExampleSentenceSource%></td>
<td class="flashcad-table-row-cell"><%= FlashcardTableRow.Tips %></td>
<td class="flashcad-table-row-cell"><%= FlashcardTableRow.Proficiency %></td>


<td class="flashcad-table-row-cell"><button type="button" class="td-icon" onclick='deleteFlashcard(<%# FlashcardTableRow.Id %>)'><img src="assets/icons/bin.png" alt="delete"/></button></td>
<td class="flashcad-table-row-cell"><button type="button" class="td-icon" onclick='showModal(<%# FlashcardTableRow.Id %>)'><img src="assets/icons/edit.png" alt="edit"/></button></td>


<input type="hidden" value='<%# FlashcardTableRow.Id %>' id="fcid" runat="server"/>

<span><button visible="false" type="button" runat="server" class="btnfcidDelete" onserverclick="btnDeleteFlashcard_Click"></button></span>
<span><button visible="false" type="button" runat="server" class="btnfcidEdit" onserverclick="btnEditFlashcard_Click"></button></span>

