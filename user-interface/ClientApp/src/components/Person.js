import React, { Component } from 'react';

export class Person extends Component {
  static displayName = Person.name;

  constructor(props) {
    super(props);
      this.state = {person: [], loading: true };
  }

    componentDidMount() {
        fetch("http://localhost:5984/people/04013a4fe3d826de43d931c45300013b")
            .then(res => res.json())
            .then((data) => {
                this.setState({ person: [data]})
            }).then((data) => {
                console.log(data)
            })
            .catch(console.log)
    }

    render() {
        return (
            <div>
                {this.state.person.map(person =>
                    <div>
                        <p>Birth date: </p><p>{person.birthDate}</p>
                    </div>
                )}
            </div>
        );
  }
}
