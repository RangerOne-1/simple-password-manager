from colorama import Fore
from cryptography.fernet import Fernet

banner="""
░█▀█░█▀█░█▀▀░█▀▀░█░█░█▀█░█▀▄░█▀▄░░░█▄█░█▀█░█▀█░█▀█░█▀▀░█▀▀░█▀▄
░█▀▀░█▀█░▀▀█░▀▀█░█▄█░█░█░█▀▄░█░█░░░█░█░█▀█░█░█░█▀█░█░█░█▀▀░█▀▄
░▀░░░▀░▀░▀▀▀░▀▀▀░▀░▀░▀▀▀░▀░▀░▀▀░░░░▀░▀░▀░▀░▀░▀░▀░▀░▀▀▀░▀▀▀░▀░▀
"""
print(Fore.BLUE+banner)
print(Fore.WHITE)

# def encrypt(message: bytes, key: bytes) -> bytes:
#     return Fernet(key).encrypt(message)

# def decrypt(token: bytes, key: bytes) -> bytes:
#     return Fernet(key).decrypt(token)

# key = b"DN6Ta7tTi1uiyM3HXuudrxWpy2mIcvpVPbMZHKzdPq4="
# message = "new world"
# print(key)
# k = encrypt(message.encode(),key)
# print(k)
# c = decrypt(k,key).decode()
# print(c)

