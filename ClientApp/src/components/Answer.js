import React, { Component } from 'react';

export class Answer extends Component {
    render() {
        return (
            <div>
                <p>Content: {this.props.content}</p>
                <p>Date Created: {this.props.date}</p>
                <p>Praise: {this.props.praise}</p>
            </div>
        );
    }
}