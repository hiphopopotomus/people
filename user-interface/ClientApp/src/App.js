import React, { Component } from 'react';
import { Route } from 'react-router';
import { Redirect } from 'react-router-dom';
import { Layout } from './components/Layout';
import { Person } from './components/Person';

import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
            <Redirect exact from='/' to='person' />
            <Route path='/person' component={Person} />
      </Layout>
    );
  }
}
