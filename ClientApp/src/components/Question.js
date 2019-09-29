import React, { Component } from 'react';

export class Question extends Component {
    render() {
        return (
            <ul className="question-list">
                <li className="question-body">
                    <h3 className="question-title">{this.props.title}</h3>   

                    <p className="question-shortdesc">{this.props.shortDesc}</p>

                    <p>{this.props.date}</p>

                    <div>
                        <span className="praise">Praises: {this.props.praise}</span>
                    </div>
                </li>
            </ul>
        );
    }
}
