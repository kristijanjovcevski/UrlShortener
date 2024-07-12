// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function copyToClipboard() {
    // Get the anchor element
    const textToCopy = document.getElementById('textToCopy');

    // Create a temporary textarea element
    const tempInput = document.createElement('textarea');
    tempInput.value = textToCopy.href; // Set the value to the href of the anchor tag
    document.body.appendChild(tempInput); // Append the textarea to the body
    tempInput.select(); // Select the text
    document.execCommand('copy'); // Copy the selected text to the clipboard
    document.body.removeChild(tempInput); // Remove the temporary textarea

    // Show the copy message
    const copyMessage = document.getElementById('copyMessage');
    copyMessage.style.display = 'block';

    // Hide the copy message after a short delay
    setTimeout(() => {
        copyMessage.style.display = 'none';
    }, 2000);
}



//function copyText() {

//    const copyText = document.getElementById('textToCopy').innerText;
//    const type = 'text/plain';
//    const blob = new Blob([copyText], { type });
//    const data = [new ClipboardItem({ [type]: blob })];

//    navigator.clipboard.write(data).then(() => {
//        document.getElementById('copyMessage').style.display = 'block';
//        setTimeout(() => {
//            document.getElementById('copyMessage').style.display = 'none';
//        }, 2000);
//    }).catch(err => {
//        alert('Oops, unable to copy');
//    });
//}

