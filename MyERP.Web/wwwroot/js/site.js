// MyERP — shared client-side behavior.
(function () {
    'use strict';

    // Enable Bootstrap dropdowns/tooltips app-wide if present.
    document.addEventListener('DOMContentLoaded', function () {
        var tooltipEls = document.querySelectorAll('[data-bs-toggle="tooltip"]');
        tooltipEls.forEach(function (el) {
            if (window.bootstrap && window.bootstrap.Tooltip) {
                new window.bootstrap.Tooltip(el);
            }
        });
    });

    // ===== Global Site Scripts =====

    // ---- Toast Notifications ----
    function showToast(message, type = "success") {
        const icons = {
            success: "fa-circle-check",
            error: "fa-circle-xmark",
            warning: "fa-triangle-exclamation",
            info: "fa-circle-info"
        };
        const colors = {
            success: "text-success",
            error: "text-danger",
            warning: "text-warning",
            info: "text-info"
        };

        const id = "toast-" + Date.now();
        const html = `
        <div id="${id}" class="toast ${type} align-items-center" role="alert" aria-live="assertive" aria-atomic="true">
          <div class="d-flex">
            <div class="toast-body d-flex align-items-center gap-2">
              <i class="fa-solid ${icons[type] || icons.info} toast-icon ${colors[type] || colors.info}"></i>
              <span>${message}</span>
            </div>
            <button type="button" class="btn-close me-2 m-auto" data-bs-dismiss="toast"></button>
          </div>
        </div>`;
        document.getElementById("toastContainer").insertAdjacentHTML("beforeend", html);
        const toastEl = document.getElementById(id);
        const toast = new bootstrap.Toast(toastEl, { delay: 4000 });
        toast.show();
        toastEl.addEventListener("hidden.bs.toast", () => toastEl.remove());
    }

    // ---- Dark Mode ----
    (function initTheme() {
        const saved = sessionStorage.getItem("theme");
        if (saved) document.documentElement.setAttribute("data-bs-theme", saved);

        document.addEventListener("DOMContentLoaded", () => {
            const btn = document.getElementById("themeToggle");
            const icon = btn?.querySelector("i");
            const current = document.documentElement.getAttribute("data-bs-theme") || "light";
            if (icon) icon.className = current === "dark" ? "fa-solid fa-sun" : "fa-solid fa-moon";

            btn?.addEventListener("click", () => {
                const now = document.documentElement.getAttribute("data-bs-theme") === "dark" ? "light" : "dark";
                document.documentElement.setAttribute("data-bs-theme", now);
                sessionStorage.setItem("theme", now);
                if (icon) icon.className = now === "dark" ? "fa-solid fa-sun" : "fa-solid fa-moon";
            });
        });
    })();

    // ---- Keyboard Shortcut: Ctrl+K focuses search ----
    document.addEventListener("keydown", (e) => {
        if ((e.ctrlKey || e.metaKey) && e.key.toLowerCase() === "k") {
            e.preventDefault();
            document.getElementById("globalSearch")?.focus();
        }
    });

    // ---- Confirmation Dialog (Bootstrap modal based) ----
    function confirmAction(message, onConfirm, opts = {}) {
        const modalId = "confirmModal";
        let modal = document.getElementById(modalId);
        if (!modal) {
            document.body.insertAdjacentHTML("beforeend", `
          <div class="modal fade" id="${modalId}" tabindex="-1">
            <div class="modal-dialog modal-dialog-centered">
              <div class="modal-content">
                <div class="modal-body text-center py-4">
                  <i class="fa-solid fa-triangle-exclamation fa-2x text-warning mb-3"></i>
                  <p id="confirmMessage" class="mb-4"></p>
                  <div class="d-flex justify-content-center gap-2">
                    <button class="btn btn-soft" data-bs-dismiss="modal">Cancel</button>
                    <button class="btn btn-danger" id="confirmActionBtn">Confirm</button>
                  </div>
                </div>
              </div>
            </div>
          </div>`);
            modal = document.getElementById(modalId);
        }

        document.getElementById("confirmMessage").textContent = message;
        const confirmBtn = document.getElementById("confirmActionBtn");
        confirmBtn.className = `btn ${opts.confirmClass || "btn-danger"}`;
        confirmBtn.textContent = opts.confirmText || "Confirm";

        const newBtn = confirmBtn.cloneNode(true);
        confirmBtn.parentNode.replaceChild(newBtn, confirmBtn);

        const bsModal = new bootstrap.Modal(modal);
        newBtn.addEventListener("click", () => {
            bsModal.hide();
            onConfirm();
        });
        bsModal.show();
    }

    // ---- Anti-forgery token helper ----
    function getAntiForgeryToken() {
        const el = document.querySelector('input[name="__RequestVerificationToken"]');
        return el ? el.value : "";
    }

    // ---- Generic POST helper ----
    async function postForm(url, data) {
        const formData = new URLSearchParams();
        Object.keys(data || {}).forEach(key => {
            const val = data[key];
            if (Array.isArray(val)) {
                val.forEach(v => formData.append(key, v));
            } else if (val !== undefined && val !== null) {
                formData.append(key, val);
            }
        });
        formData.append("__RequestVerificationToken", getAntiForgeryToken());

        const res = await fetch(url, {
            method: "POST",
            headers: { "X-Requested-With": "XMLHttpRequest" },
            body: formData
        });
        return res.json();
    }



})();

