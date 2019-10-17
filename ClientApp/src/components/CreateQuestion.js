import React, { useState } from 'react'
import axios from 'axios'

export const CreateQuestion = () => {
  const [title, setTitle] = useState('')
  const [content, setContent] = useState('')

  const addQuestion = async e => {
    await axios.post(`https://localhost:5001/api/Question/CreateQuestion`, {
      shortDescription: title,
      content: content
    })
  }

  const updateTitle = e => {
    setTitle(e.target.value)
  }

  const updateContent = e => {
    setContent(e.target.value)
  }

  return (
    <main className="card m-xl-2">
      <form className="card-body" onSubmit={addQuestion}>
        <input
          className="title-container"
          placeholder="Title"
          required
          type="text"
          onChange={updateTitle}
        />
        <input
          className="content-container"
          placeholder="Content"
          required
          type="text"
          onChange={updateContent}
        />
        <button className="submit btn btn-primary">Submit</button>
      </form>
    </main>
  )
}
