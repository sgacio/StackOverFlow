import React, {useState} from 'react'
import axios from 'axios'

export const CreateQuestion = () => {
    const [title, setTitle] = useState('')
    const [content, setContent] = useState('')

    const addQuestion = async (e) => {
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
        <>
            <form onSubmit={addQuestion}>
                <input placeholder='Title' required type='text' onChange={updateTitle}/>
                <input placeholder='Content' required type='text' onChange={updateContent}/>
                <button>Submit</button>
            </form>
        </>
    );
}