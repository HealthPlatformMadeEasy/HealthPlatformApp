import Fuse from "fuse.js";
import {useEffect, useState} from "react";

const foods = ["apple", "banana", "cherry" /*...*/]; // Your array of 2000 foods

const fuseOptions: Fuse.IFuseOptions<{ title: string }> = {
    keys: ["title"],
    includeMatches: true,
    threshold: 0.3,
};

const fuse = new Fuse(
    foods.map((food) => ({title: food})),
    fuseOptions,
);

export function SearchBar() {
    const [showSearchItem, setShowSearchItem] = useState(true);
    const [query, setQuery] = useState("");
    const [results, setResults] = useState<Fuse.FuseResult<{ title: string }>[]>(
        [],
    );

    useEffect(() => {
        if (query) {
            const searchResults = fuse.search(query);
            setResults(searchResults);
        } else {
            setResults([]);
        }
    }, [query]);

    return (
        <div>
            <input
                type="text"
                placeholder="Search for a food..."
                value={query}
                onChange={(e) => {
                    setQuery(e.target.value);
                    setShowSearchItem(true);
                }}
            />
            <ul>
                {showSearchItem &&
                    results.map((result, index) => (
                        <li
                            key={index}
                            onClick={() => {
                                setQuery(result.item.title);
                                setShowSearchItem(false);
                            }}
                            className="hover:cursor-pointer"
                        >
                            {result.item.title}
                        </li>
                    ))}
            </ul>
        </div>
    );
}
