export function LoginButton(props: { handleOpenModal: () => void }) {
    return (
        <button onClick={props.handleOpenModal}
                className="ml-4  relative group overflow-hidden px-6 h-12 rounded-full flex space-x-2 items-center
                bg-gradient-to-r from-tea_green-800 via-pine_green-600 to-pine_green-700 transform transition duration-300
                 ease-in-out hover:scale-110">
                    <span className="relative text-m text-white">
                        Login
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
    )
}
