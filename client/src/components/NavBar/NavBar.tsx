import {useState} from 'react'
import Modal from "react-modal";
import {NavLink} from "react-router-dom";
import {LoginForm} from "../Forms";
import {LoginButton} from "../Buttons";

export function Navbar() {
    const [isModalOpen, setModalOpen] = useState(false);

    const handleOpenModal = () => {
        setModalOpen(true);
    };

    const handleCloseModal = () => {
        setModalOpen(false);
    };

    return (
        <nav className="sticky top-0 z-50 flex items-center justify-between p-6">
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
                        className="transform transition duration-300 ease-in-out hover:scale-125 mr-4 text-lg">
                        <NavLink to='/charts'
                                 className={({isActive}) => isActive ? 'text-green-700 hover:font-bold p-2 hover:text-green-700' : 'text-gray-500 hover:font-bold p-2 hover:text-green-700'}>
                            Charts
                        </NavLink>
                    </button>
                    <button
                        className="transform transition duration-300 ease-in-out hover:scale-125 mr-4 font-raleway font-semibold text-lg">
                        <NavLink to='/test'
                                 className={({isActive}) => isActive ? 'text-marian_blue-700 hover:font-bold p-2 hover:text-marian_blue-900' : 'text-gray-500 hover:font-bold p-2 hover:text-green-700'}>
                            Test
                        </NavLink>
                    </button>
                    <button
                        className="transform transition duration-300 ease-in-out hover:scale-125 mr-4 font-raleway font-semibold text-lg">
                        <NavLink to='/login'
                                 className={({isActive}) => isActive ? 'text-marian_blue-700 hover:font-bold p-2 hover:text-marian_blue-900' : 'text-gray-500 hover:font-bold p-2 hover:text-green-700'}>
                            Login
                        </NavLink>
                    </button>
                </div>
                <LoginButton handleOpenModal={() => handleOpenModal()}/>
            </div>
            <Modal ariaHideApp={false} isOpen={isModalOpen} onRequestClose={handleCloseModal}>
                <LoginForm setModalOpen={setModalOpen}/>
            </Modal>
        </nav>
    )
}
