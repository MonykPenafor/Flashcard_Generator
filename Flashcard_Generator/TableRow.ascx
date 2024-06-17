<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TableRow.ascx.cs" Inherits="Flashcard_Generator.TableRow" %>


<td class="flashcad-table-row-cell"><%= FlashcardTableRow.WordTarget %> <br /> <%= FlashcardTableRow.WordSource%></td>
<td class="flashcad-table-row-cell"><%= FlashcardTableRow.ExampleSentenceTarget %> <br /> <%= FlashcardTableRow.Pronunciation%> <br /> <%= FlashcardTableRow.ExampleSentenceSource%></td>
<td class="flashcad-table-row-cell"><%= FlashcardTableRow.Tips %></td>
<td class="flashcad-table-row-cell"><%= FlashcardTableRow.Proficiency %></td>


<td class="flashcad-table-row-cell"><asp:LinkButton runat="server" type="button" CommandArgument='<%# FlashcardTableRow.Id %>' OnClick="btnEditFlashcard_Click" CssClass="td-icon"><img src="assets/icons/edit.png" alt="edit"/></asp:LinkButton></td>
<td class="flashcad-table-row-cell"><asp:LinkButton runat="server" CommandArgument='<%# FlashcardTableRow.Id %>' OnClick="btnDeleteFlashcard_Click" CssClass="td-icon"><img src="assets/icons/bin.png" alt="delete"/></asp:LinkButton></td>

<input type="hidden" value='<%# FlashcardTableRow.Id %>' id="ide" runat="server"/>

<td class="flashcad-table-row-cell"><linkbutton type="button" onclick="showModal(<%# FlashcardTableRow.Id %>)" class="td-icon"><img src="assets/icons/edit.png" alt="edit"/></linkbutton></td>
<td class="flashcad-table-row-cell"><linkbutton type="button" onclick="deleteFlashcard(<%# FlashcardTableRow.Id %>)" class="td-icon"><img src="assets/icons/bin.png" alt="edit"/></linkbutton></td>
