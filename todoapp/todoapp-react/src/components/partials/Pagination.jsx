import React from "react";

export default function Pagination({ numberOfPages, currentPage, setCurrentPage }) {
  return (
    <>
      <div className="pagination">
        {Array.from({ length: numberOfPages }, (v, i) => i + 1).map((page) => (
          <PaginationItem key={page} page={page} currentPage={currentPage} setCurrentPage={setCurrentPage} />
        ))}
      </div>
    </>
  );
}

function PaginationItem({ page, currentPage, setCurrentPage }) {
  return (
    <>
      <div className="pagination-item">
        <button
          className={`pagination-item__button ${page === currentPage ? "pagination-item__button--active" : ""}`}
          onClick={() => setCurrentPage(page)}
        >
          {page}
        </button>
      </div>
    </>
  );
}
