function PrintQRCode(elementId) {
    const printContent = document.getElementById(elementId).innerHTML;
    const printWindow = window.open('', '_blank');
    printWindow.document.open();
    printWindow.document.write('<html><head><title>Print</title>');
    printWindow.document.write('<style>@media print {.barcode-container {border: 1px dashed black; padding: 10px;}}</style>');
    printWindow.document.write('</head><body>');
    printWindow.document.write(printContent);
    printWindow.document.write('</body></html>');
    printWindow.document.close();
    printWindow.print();
}