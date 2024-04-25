var pdfPath = "";

var BaseURl = "https://localhost:7261";
//    localStorage.getItem("BASEURL");

function fieUplaod() {
    debugger;
    var data = {};
    data.pdfFileName = pdfPath;
    $.ajax({
        type: "POST",
        url: BaseURl + "/api/PdfColorFile",
        data: data,
        success: function (newResponse) {
            debugger;
            var blob = new Blob([newResponse.aecbdfilePath], { type: 'application/pdf' });

            // Create a URL for the Blob
            var blobUrl = URL.createObjectURL(blob);

            // Open the PDF in a new window
            window.open(blobUrl, '_blank');

        },
        error: function (errorData) {
            // Handle error of the second AJAX call
        }
    });
}


function UploadPdfFile() {
    debugger;
    var formData = new FormData();
    formData.append('file', $("#colorPdf")[0].files[0]);

    $.ajax({
        url: BaseURl + '/api/UploadFile',
        type: 'POST',
        data: formData,
        processData: false,
        contentType: false,
        success: function (data) {
            debugger;
            pdfPath = data.data;

        }
    });
}
