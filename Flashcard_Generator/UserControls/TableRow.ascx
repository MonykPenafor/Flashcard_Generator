<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TableRow.ascx.cs" Inherits="Flashcard_Generator.TableRow" %>


<td class="flashcad-table-row-cell">
    <span class="tr-word-target"><%= FlashcardTableRow.WordTarget %></span><br />
    <span class="tr-word-source"><%= FlashcardTableRow.WordSource %></span>
</td>
<td class="flashcad-table-row-cell">
    <span class="tr-example-target"><%= FlashcardTableRow.ExampleSentenceTarget %></span><br />
    <span class="tr-pronunciation"><%= FlashcardTableRow.Pronunciation %></span><br />
    <span class="tr-example-source"><%= FlashcardTableRow.ExampleSentenceSource %></span>
</td>
<td class="flashcad-table-row-cell"><span class="tr-tips"><%= FlashcardTableRow.Tips %></span></td>
<td class="flashcad-table-row-cell"><span class="tr-level"><%= FlashcardTableRow.Proficiency %></span></td>
<td class="flashcad-table-row-cell"><span class="tr-isPublic"><%= FlashcardTableRow.IsPublic %></span></td>

<td class="flashcad-table-row-cell"><button class="td-icon" type="button" onclick='deleteFlashcard(<%# FlashcardTableRow.Id %>)'><img src="/assets/icons/bin.png" alt="delete"/></button></td>



<td class="flashcad-table-row-cell"><button type="button" class="td-icon" onclick='showModal(<%# FlashcardTableRow.Id %>)'><img src="/assets/icons/edit.png" alt="edit"/></button></td>


