import React, { Component } from 'react'
import { BrowserRouter as Router, Route, Switch } from "react-router-dom"
import { Home } from './components/Home'
import { Navbar } from './components/Navbar'
import {SpecificQuestion} from './components/SpecificQuestion'
import {CreateQuestion} from './components/CreateQuestion'

export default class App extends Component {
  static displayName = App.name

  render() {
    return (
      <>
        <Router>
          <Navbar />
          <Switch>
            <Route exact path='/question/:id' component={SpecificQuestion} />
            <Route exact path='/createquestion' component={CreateQuestion} />
            <Route exact path='/home' component={Home} />
          </Switch>
        </Router>
      </>
    )
  }
}
