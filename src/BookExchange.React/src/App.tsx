import React, { useState } from "react";
import "./App.css";

import { Route, Switch } from "react-router-dom";

import Home from "./Home";
import { Contact } from "./Contact";
import { SearchBooks } from "./modules/search-books";
import { BookDetails } from "./modules/book-page";
import { PostBooks } from "./modules/post-books";

import { Navbar } from "./components/navbar";
import { useToken } from "./hooks";
import { SignIn } from "./modules/sign-in";

function App() {
  const { token, setToken } = useToken();

  return (
    <div>
      <Navbar />
      <h1>...</h1>
      <Switch>
        <Route exact path="/sign-in" component={SignIn} />
        <Route exact path="/" component={Home} />
        <Route exact path="/search" render={(props) => <SearchBooks />} />
        <Route exact path="/book/:id" component={BookDetails} />
        <Route exact path="/post-book" component={PostBooks} />

        <Route exact path="/contact" component={Contact} />
      </Switch>
    </div>
  );
}

export default App;
