import {useState} from 'react'
import LoginForm from "../LogSignModal/LoginForm.tsx";
import Modal from "react-modal";
import {NavLink} from "react-router-dom";


export const Navbar = () => {
    const [isModalOpen, setModalOpen] = useState(false);

    const handleOpenModal = () => {
        setModalOpen(true);
    };

    const handleCloseModal = () => {
        setModalOpen(false);
    };

    return (
        <nav className="flex items-center justify-between p-6">
            <div className="flex items-center flex-no-shrink text-green-700 mr-6">
                <span className="font-semibold text-3xl">
                    Health App
                </span>
            </div>
            <div id="nav-content" className="flex items-center">
                <div className="text-sm lg:flex-grow mr-auto space-x-4">
                    <button
                        className="transform transition duration-300 ease-in-out hover:scale-125 mr-4 text-lg">
                        <NavLink to='/' end
                                 className={({isActive}) => isActive ? 'text-green-700 hover:font-bold p-2 hover:text-green-700' : 'text-gray-500 hover:font-bold p-2 hover:text-green-700'}>
                            Home
                        </NavLink>
                    </button>
                    <button
                        className="transform transition duration-300 ease-in-out hover:scale-125 mr-4 text-lg">
                        <NavLink to='/user-food'
                                 className={({isActive}) => isActive ? 'text-green-700 hover:font-bold p-2 hover:text-green-700' : 'text-gray-500 hover:font-bold p-2 hover:text-green-700'}>
                            User Food
                        </NavLink>
                    </button>
                    <button
                        className="transform transition duration-300 ease-in-out hover:scale-125 hover:text-red-600 mr-4 p-2 text-lg">
                        Macros Graph
                    </button>
                </div>
                <button onClick={() => handleOpenModal()}
                        className="ml-4 relative group overflow-hidden px-6 h-12 rounded-full flex space-x-2 items-center bg-gradient-to-r from-pink-500 to-purple-500 hover:to-purple-600">
                    <span className="relative text-sm text-white">
                        Log In
                    </span>
                    <div className="flex items-center -space-x-3 translate-x-3">
                        <div
                            className="w-2.5 h-[1.6px] rounded bg-white origin-left scale-x-0 transition duration-300 group-hover:scale-x-100"></div>
                        <svg xmlns="http://www.w3.org/2000/svg"
                             className="h-5 w-5 stroke-white -translate-x-2 transition duration-300 group-hover:translate-x-0"
                             fill="none" viewBox="0 0 24 24" stroke="currentColor" strokeWidth="2">
                            <path strokeLinecap="round" strokeLinejoin="round" d="M9 5l7 7-7 7"/>
                        </svg>
                    </div>
                </button>
            </div>
            <Modal ariaHideApp={false} isOpen={isModalOpen} onRequestClose={handleCloseModal}>
                <LoginForm setModalOpen={setModalOpen}/>
            </Modal>
        </nav>
    )
}
