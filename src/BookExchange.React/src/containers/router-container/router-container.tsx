import React from "react";
import { BrowserRouter as Router, Route, Switch } from "react-router-dom";

import { Navbar } from "../../components/navbar";
import { Userbar } from "../../components/userbar";
import { HomePage } from "../../modules/home-page/home-page";
import { SignInPage } from "../../modules/sign-in-page";
import { SignUpPage } from "../../modules/sign-up-page";
import { BookDetails } from "../../modules/book-page";
import { PostBooks } from "../../modules/post-books";
import { SearchBooks } from "../../modules/search-books";
import { AddBook } from "../../modules/add-book";
import { ProfilePage } from "../../modules/profile-page";
import { AddPost } from "../../modules/add-post";

import { PurchaseCoinsCallback, CancelPaymentCallback } from "../../callbacks";

interface RouterContainerProps {
  children: React.ReactNode;
}

const RouterContainer = () => {
  return (
    <Router>
      <Navbar />
      <h1>...</h1>
      <Userbar />
      <Switch>
        <Route
          exact
          path="/callbacks/single-payment/finish"
          component={PurchaseCoinsCallback}
        />
        <Route
          exact
          path="/callbacks/single-payment/cancel"
          component={CancelPaymentCallback}
        />
        <Route exact path="/" component={HomePage} />
        <Route exact path="/sign-in" component={SignInPage} />
        <Route exact path="/sign-up" component={SignUpPage} />
        <Route exact path="/profile" component={ProfilePage} />
        <Route exact path="/search" render={(props) => <SearchBooks />} />
        <Route exact path="/book/:id" component={BookDetails} />
        <Route exact path="/post-book" component={PostBooks} />

        <Route exact path="/add-book" component={AddBook} />
        <Route exact path="/posts/add/:bookId" component={AddPost} />
      </Switch>
    </Router>
  );
};

export { RouterContainer };
