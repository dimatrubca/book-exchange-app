import React from "react";
// import PostBooks from './PostBooks';
import { PostBooks } from "./modules/post-books";
const Home = () => {
  return (
    <>
      {/* <PostBooks/> */}
      <h1>Hello</h1>
      {/* <BookDetails title="Essentialism" isbn="1222222222123" 
                categories={["Self Improvement"]}
                authors={["Greg McKeown"]}
                description="Short Description"
                imagePath="https://images-na.ssl-images-amazon.com/images/I/41TVwg27ujL._SX331_BO1,204,203,200_.jpg"
                published= "12/10/2015"
                publisher="Penguin Random House"/>  */}
      {/* <SearchBooks /> */}
      <PostBooks />
    </>
  );
};

export default Home;
