//document.getElementById("btnCreate").addEventListener("click", function () {
//    document.getElementById("modalCreate").style.display = "block";
//});

//document.querySelectorAll(".btnDelete").forEach(button => {
//    button.addEventListener("click", function () {
//        let id = this.getAttribute("data-id");
//        if (confirm("Bạn có chắc chắn muốn xóa?")) {
//            fetch(`/Category/Delete/${id}`, { method: "POST" })
//                .then(() => location.reload());
//        }
//    });
//});
//document.addEventListener("DOMContentLoaded", function () {
//    const createForm = document.getElementById("createForm");
//    const editForm = document.getElementById("editForm");
//    const deleteForm = document.getElementById("deleteForm");

//    // Xử lý form Create
//    if (createForm) {
//        createForm.addEventListener("submit", function (event) {
//            event.preventDefault();
//            handleSubmit(createForm, "/Category/Create");
//        });
//    }

//    // Xử lý form Edit
//    if (editForm) {
//        editForm.addEventListener("submit", function (event) {
//            event.preventDefault();
//            handleSubmit(editForm, "/Category/Edit");
//        });
//    }

//    // Xử lý form Delete
//    if (deleteForm) {
//        deleteForm.addEventListener("submit", function (event) {
//            event.preventDefault();
//            if (confirm("Bạn có chắc chắn muốn xóa danh mục này?")) {
//                handleSubmit(deleteForm, "/Category/Delete");
//            }
//        });
//    }

//    // Hàm gửi dữ liệu AJAX
//    function handleSubmit(form, url) {
//        const formData = new FormData(form);

//        fetch(url, {
//            method: "POST",
//            body: formData,
//        })
//            .then(response => response.json())
//            .then(data => {
//                if (data.success) {
//                    alert("Thao tác thành công!");
//                    window.location.href = "/Category/Index";
//                } else {
//                    alert("Có lỗi xảy ra, vui lòng thử lại!");
//                }
//            })
//            .catch(error => {
//                console.error("Lỗi:", error);
//                alert("Lỗi hệ thống!");
//            });
//    }
//});

