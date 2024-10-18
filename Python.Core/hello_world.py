def format_name(name: str, max_length: int = 100) -> str:
	return "Hello {}".format(name.capitalize())[:max_length]