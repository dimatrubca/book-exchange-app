const GetBooks = () => {
  console.log("getting books");
  return fetch("https://localhost:5001/api/book").then((data) => data.json());
};

const GetBookById = (id: number) => {
  return fetch(`https://localhost:5001/book/${id}`).then((data) => data.json());
};

const BookService = {
  GetBooks,
  GetBookById,
};

export { BookService };
