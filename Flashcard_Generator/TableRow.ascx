<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TableRow.ascx.cs" Inherits="Flashcard_Generator.TableRow" %>

<td class="flashcad-table-row-cell hidden"><%= FlashcardTableRow.Id %></td>
<td class="flashcad-table-row-cell"><input type="checkbox" /></td>
<td class="flashcad-table-row-cell"><%= FlashcardTableRow.WordTarget %> <br /> <%= FlashcardTableRow.WordSource%></td>
<td class="flashcad-table-row-cell"><%= FlashcardTableRow.ExampleSentenceTarget %> <br /> <%= FlashcardTableRow.Pronunciation%> <br /> <%= FlashcardTableRow.ExampleSentenceSource%></td>
<td class="flashcad-table-row-cell"><%= FlashcardTableRow.Tips %></td>
<td class="flashcad-table-row-cell"><%= FlashcardTableRow.Proficiency %></td>
<td class="flashcad-table-row-cell"><asp:LinkButton runat="server" CommandArgument='<%# FlashcardTableRow.Id %>' OnClick="btnEditItem_Click" CssClass="td-icon"><img src="assets/icons/edit.png" alt="edit"/></asp:LinkButton></td>
<td class="flashcad-table-row-cell"><asp:LinkButton runat="server" CommandArgument='<%# FlashcardTableRow.Id %>' OnClick="btnDeleteItem_Click" CssClass="td-icon"><img src="assets/icons/bin.png" alt="delete"/></asp:LinkButton></td>
