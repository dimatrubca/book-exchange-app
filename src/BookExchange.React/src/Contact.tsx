import React from "react";

class Contact extends React.Component<any, any> {
  constructor(props: any) {
    super(props);

    this.state = {
      counter: 0,
    };
    this.onClick.bind(this);
  }

  onClick() {
    this.setState({
      counter: 2 + this.state.counter,
    });

    console.log(this.state.counter);
  }

  render() {
    return (
      <div>
        <button onClick={() => this.onClick()}>My Button</button>
        <h1>1</h1>
        <h1>2</h1>
      </div>
    );
  }
}

export { Contact };
